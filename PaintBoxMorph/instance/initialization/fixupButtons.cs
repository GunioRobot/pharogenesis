fixupButtons
	| changes answer newSelector |
	changes := Dictionary new.
	changes
		at: #brush:action:nib: put: #brush:action:nib:evt:;
		at: #tool:action:cursor: put: #tool:action:cursor:evt:;
		at: #pickup:action:cursor: put: #pickup:action:cursor:evt:;
		at: #keep:with: put: #keep:with:evt:;
		at: #undo:with: put: #undo:with:evt:;
		at: #scrollStamps:action: put: #scrollStamps:action:evt:;
		at: #toss:with: put: #toss:with:evt:;
		at: #eyedropper:action:cursor: put: #eyedropper:action:cursor:evt:;
		at: #clear:with: put: #clear:with:evt:.
	answer := WriteStream on: String new.
	self allMorphsDo: 
			[:each | 
			(each isKindOf: ThreePhaseButtonMorph) 
				ifTrue: 
					[answer nextPutAll: each actionSelector.
					(changes includesKey: each actionSelector) 
						ifTrue: 
							[each actionSelector: (newSelector := changes at: each actionSelector).
							answer nextPutAll: ' <-- ' , newSelector].
					answer cr]].
	^answer contents
	"StringHolder new
		contents: answer contents;
		openLabel: 'button fixups'"