scanFile: file category: cat class: class meta: meta stamp: stamp
	| itemPosition method items |
	items := OrderedCollection new.
	[itemPosition _ file position.
	method _ file nextChunk.
	file skipStyleChunk.
	method size > 0] whileTrue:[
		items add: (ChangeRecord new file: file position: itemPosition type: #method
							class: class category: cat meta: meta stamp: stamp)].
	^items