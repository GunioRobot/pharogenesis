targetFromMenu: aMenu popupAt: aPoint 
	"Some other morph become target of the receiver"
	| newTarget |
	newTarget := aMenu startUpWithCaption: self externalName , ' targets... '
	at: aPoint .
	"self halt ."
	newTarget
		ifNil: [^ self].
	self target: newTarget