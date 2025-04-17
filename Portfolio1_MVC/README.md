# Introduction to ASP.NET Core MVC (.NET 8)
This is a follow along of the course [Introduction to ASP.NET Core MVC (.NET 8)](https://youtu.be/AopeJjkcRvU?t=26845) an introduction to MVC (Model-View-Controller) with .NET 8. 

## Topics Covered
* Validations [Server-side] & [Client-side] (min 02:38:00)
* Custom Validation - Server-side (min 02:45:30)
* Client-side Validation (min 02:53:42)
* Usage of Partial Views (min 02:56:00)
* Update - Delete Category (min 02:58:40)
* CRUD Operations for Category (min 03:24:00)
* TempData Notifications (min 03:25:00)
* Toastr Library Notifications (min 03:30:38)
* Razor Pages (min 03:36:21)
* Library: Data Access, Utility, Models (min 04:19:40)
* Setting Up a New Bootstrap Theme (Bootswatch) (min 04:21:40)
* Injection Lifetime (min 04:46:10)
* Repository Pattern (min 04:57:40)
* Areas (min 05:37:00)
* Select Options / asp-items (min 06:20:00)
* View Model: Specific Model for a View (min 06:30:00)
* Merging Create and Update Views (min 06:40:00)
* Image Upload Field (min 00:00:00)
* Navigation Properties (Foreign Key) (min 07:20:14)
* Search Functionality on Table, Pagination, Filtering (min 07:25:00)
* Sweet Alert (min 07:44:44)
* Home Page and Details (min 07:54:00)
* Identity (min 08:00:00)

![Home Screen](https://github.com/lonchanick/Portfolio1_MVC/blob/master/wwwroot/Images/Book/homescreen.png)


## HOW TO IMPLEMENT REPOSITORY PATTERN

>CREATE INTERFACE: IRepository<T> where T : class (T -> Category)
	|IEnumerable<T> GetAll();
	|T Get(IExpression<Func<T,bool>> filter);
	|Add(T Entity);
	|Remove(T entity);
	|RemoveRange(IEnumerable<T> entities)
	|Update();//not for now

>CREATE A GENERIC CLASS: class Repository<T> : IRepository<T> where T : class
	>note: when we are implementing a generic interface, class which implement this interface must be generic too.
	>entityframework:
		constructor(dbContext Db)
		{
			this.db = Db;
			this.EntityCategory = Db.set<T>;
		}

>CREATE AN INTERFACE: ICategoryRepository : IRepository<Category>
	|Update();
	|Save();
	|Note: This needed because Update method required more complex logic implementation


>CREATE A CLASS: CategoryRepository : Repository<Category>, ICategoryRepository
	|Update();
	|Save();
	|Note: This needed because Update method required more complex logic implementation

