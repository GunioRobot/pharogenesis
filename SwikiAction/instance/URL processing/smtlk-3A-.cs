smtlk: request
	"Return Smalltalk sourcecode.  URL =
machine:80/myswiki.smtlk.Point|at;  included are:  Point|at:
Point|Comment   Point|Hierarchy  Point|Definition   Point|class|x;y;  NOTE:
use ; instead of : in selector names!!!"

	| classAndMethod set |

	classAndMethod _ request message atPin: 3.
	classAndMethod _
classAndMethod copyReplaceAll: '|' with: ' '.
	classAndMethod _
classAndMethod copyReplaceAll: ';' with: ':'.
	set _ LinkedMessageSet
messageList: (Array with: classAndMethod).

	request reply: PWS crlf,
((self formatterFor: 'smtlk') format: set).