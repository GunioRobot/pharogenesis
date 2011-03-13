smtlk: request
	"Return Smalltalk sourcecode in HTML.  URL = machine:80/myswiki.smtlk.Point|min;  included are:  Point|min;   Point|Comment   Point|Hierarchy  Point|Definition   Point|class|x;y;  
NOTE: use ; instead of : in selector names!!!"

	| classAndMethod set |
	classAndMethod _ request message atPin: 2.
	classAndMethod _ classAndMethod copyReplaceAll: '|' with: ' '.
	classAndMethod _ classAndMethod copyReplaceAll: ';' with: ':'.
	set _ LinkedMessageSet messageList: (Array with: classAndMethod).

	request reply: PWS crlf, (HTMLformatter 
				evalEmbedded: (self fileContents: 'swiki',(ServerAction pathSeparator),'smtlk.html')
				with: set).