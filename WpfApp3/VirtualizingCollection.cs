using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.ViewModels;
using ContactCatalog;

namespace WpfApp3
{
    public class VirtualizingCollection : IList<Contact>, IList
    {

        private readonly IContactManager _contactManager;
        private readonly int _pageSize = 100;
        private readonly int _pageTimeout = 10000;
        private int _count = -1;
        private readonly Dictionary<int, IList<Contact>> _pages = new Dictionary<int, IList<Contact>>();
        private readonly Dictionary<int, DateTime> _pageTouchTimes = new Dictionary<int, DateTime>();
        
        public VirtualizingCollection(IContactManager contactManager, int pageSize, int pageTimeout)
        {
            this._contactManager = contactManager;
            this._pageSize = pageSize;
            this._pageTimeout = pageTimeout;
        }

        public VirtualizingCollection(IContactManager contactManager, int pageSize)
        {
            this._contactManager = contactManager;
            this._pageSize = pageSize;
        }

        public VirtualizingCollection(IContactManager contactManager)
        {
            this._contactManager = contactManager;
        }

        public void CleanUpPages()
        {
            List<int> keys = new List<int>(_pageTouchTimes.Keys);
            foreach (int key in keys)
            {
                if (key != 0 && (DateTime.Now - _pageTouchTimes[key]).TotalMilliseconds >_pageTimeout)
                {
                    _pages.Remove(key);
                    _pageTouchTimes.Remove(key);
                    Trace.WriteLine("Removed Page: " + key);
                }
            }
        }

        protected virtual void PopulatePage(int pageIndex, IList<Contact> page)
        {
            Trace.WriteLine("Page Populated: " + pageIndex);
            if (_pages.ContainsKey(pageIndex))
            {
                _pages[pageIndex] = page;
            }
        }

        protected virtual void RequestPage(int pageIndex)
        {
            if (!_pages.ContainsKey(pageIndex))
            {
                _pages.Add(pageIndex, null);
                _pageTouchTimes.Add(pageIndex, DateTime.Now);
                Trace.WriteLine("Added page: " + pageIndex);
                LoadPage(pageIndex);
            }
            else
            {
                _pageTouchTimes[pageIndex] = DateTime.Now;
            }
        }

        protected virtual void LoadCount()
        {
            Count = FetchCount();
        }

        protected virtual void LoadPage(int pageIndex)
        {
            PopulatePage(pageIndex, FetchPage(pageIndex));
        }

        protected int FetchCount()
        {
            return _contactManager.GetCount();
        }

        protected IList<Contact> FetchPage(int pageIndex)
        {
            List<Contact> c = new List<Contact>();
            var models = _contactManager.GetContactsRange(pageIndex * _pageSize, _pageSize).ToList();
            foreach (var m in models)
            {
                c.Add(ContactModelToContact.Convert(m));
            }
            return c;
        }

        public virtual int Count
        {
            get
            {
                if (_count == -1)
                {
                    LoadCount();
                }
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        public Contact this[int index]
        {
            get
            {
                int pageIndex = index / _pageSize;
                int pageOffset = index % _pageSize;

                RequestPage(pageIndex);

                if (pageOffset > _pageSize / 2 && pageIndex < Count / _pageSize)
                    RequestPage(pageIndex + 1);

                if (pageOffset < _pageSize / 2 && pageIndex > 0)
                    RequestPage(pageIndex - 1);

                CleanUpPages();

                if (_pages[pageIndex] == null)
                    return default(Contact);

                return _pages[pageIndex][pageOffset];
            }
            set { throw new NotSupportedException(); }
        }

        public IEnumerator<Contact> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public int IndexOf(Contact item)
        {
            return IndexOf(item);
        }

        public int IndexOf(object value)
        {
            return -1;
        }
  
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        



        //Not Supported
        public void Add(Contact item)
        {
            throw new NotImplementedException();
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Contact item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Contact[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Contact item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Contact item)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

    }
}
