wakeUp
	"Open for FTP and keep the connection open"

	| so |
	(so _ self openNoDataFTP) class == String ifTrue: [^ so].
	^ socket _ so