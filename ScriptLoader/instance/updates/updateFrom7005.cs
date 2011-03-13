updateFrom7005
	"self new updateFrom7005"
	"
	- fixed #binding
	- 0003249: Mac VM pops up debugger on every launch (InternetConfiguration broken?)
	- 0003246: In 7005 Getting objects from Object morph not behaving as expected.
	- 0003245: 7005: ProcessBrowser DNU
	"
	self script44.
	self flushCaches.
	Compiler recompileAll.