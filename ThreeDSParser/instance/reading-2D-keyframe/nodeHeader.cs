nodeHeader
	"Subchunk of node"
	| name hierarchy unknown isHidden |
	name := self cString.
	unknown := (1 to: 4) collect: [:i | source next].
	hierarchy := self short.
	isHidden := (unknown at: 2) anyMask: 8.
	log ==nil ifFalse: [log crtab: indent; 
		nextPutAll: 'Name: '; print: name; nextPutAll: ' Hierarchy: '; print: hierarchy; 
		nextPutAll: ' Unknown: '; print: unknown.
		(isHidden) ifTrue:[log nextPutAll:' hidden'.]].
	^Array with: (#name->name)
		with: (#hierarchy->hierarchy)
		with:(#hidden -> isHidden)