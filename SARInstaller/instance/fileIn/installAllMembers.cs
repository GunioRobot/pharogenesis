installAllMembers
	"Try to install all the members, in order, based on their filenames and/or contents."
	| uninstalled |
	uninstalled _ OrderedCollection new.
	zip members do: [ :member | self installMember: member ].
	uninstalled _ self uninstalledMembers.
	uninstalled isEmpty ifTrue: [ ^self ].
	uninstalled inspect.