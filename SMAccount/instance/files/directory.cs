directory
	"Get the directory for the account."

	| dir |
	dir := (map directory directoryNamed: 'accounts') assureExistence; yourself.
	^(dir directoryNamed: id asString) assureExistence; yourself
