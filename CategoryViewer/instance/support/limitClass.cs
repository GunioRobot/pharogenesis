limitClass
	"Answer the receiver's limitClass"

	| outer |
	^ (outer _ self outerViewer)
		ifNotNil:
			[outer limitClass]
		ifNil:
			[ProtoObject]