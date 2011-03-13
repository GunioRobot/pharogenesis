browseFullProtocol
	"Open up a protocol-category browser on the value of the receiver's current selection.    If in mvc, an old-style protocol browser is opened instead.  Someone who still uses mvc might wish to make the protocol-category-browser work there too, thanks.  The temporary circumlocution regarding the presence/absence of ProtocolCategoryBrowser is of course quite temporary."

	| aClass |
	(Smalltalk isMorphic and: [Smalltalk includesKey: #ProtocolCategoryBrowser]) ifFalse: [^ self spawnFullProtocol].
	(aClass _ self selectedClassOrMetaClass) ifNotNil:
		[(Smalltalk at: #ProtocolCategoryBrowser) new openOnClass: aClass targetObject: nil inWorld: self currentWorld showingSelector: self selectedMessageName]