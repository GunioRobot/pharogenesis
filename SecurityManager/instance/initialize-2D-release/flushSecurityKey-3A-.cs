flushSecurityKey: aKey
	"Flush a security key"
	| n |
	n _ aKey first.
	1 to: n basicSize do:[:i| n basicAt: i put: 0].
	n _ aKey second.
	1 to: n basicSize do:[:i| n basicAt: i put: 0].
