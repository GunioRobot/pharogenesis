directory
	"Get the directory for the account."

	| dir |
	dir _ (map directory directoryNamed: 'accounts') assureExistence; yourself.
	^(dir directoryNamed: id asString) assureExistence; yourself
