setUp: actionName
	"Set up a named protected Swiki"
	| action auth |

	super setUp: actionName.
	action _ PWS actions at: actionName.
	auth _ Authorizer new.	"*** for now, not restored from the disk***"
	auth realm: actionName.
	action auth: auth.
	^ action
