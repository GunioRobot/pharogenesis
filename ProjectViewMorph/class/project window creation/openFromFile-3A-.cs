openFromFile: preStream
	"Reconstitute a Morph from the selected file, presumed to be represent a Morph saved via the SmartRefStream mechanism, and open it in an appropriate Morphic world."
 	| morphOrList window proj |

	morphOrList _ preStream asUnZippedStream fileInObjectAndCode.
	(morphOrList isKindOf: ImageSegment) ifTrue: [
		(morphOrList arrayOfRoots count: [:mm | mm class == Project]) > 1 ifTrue: [
			self error: 'which project is main?']. 	"debug"
		proj _ morphOrList arrayOfRoots detect: [:mm | mm class == Project] 
					ifNone: [nil].
		"rename the project if it conflicts?"
		proj ifNotNil: [proj versionFrom: preStream.
			window _ (SystemWindow labelled: proj name) model: proj.
			window
				addMorph: (self on: proj)
				frame: (0@0 corner: 1.0@1.0).
			window openInWorld.
			proj setParent: Project current.
			^ proj enter]].

	(morphOrList isKindOf: SqueakPage) ifTrue: [
		morphOrList _ morphOrList contentsMorph].
	(morphOrList isKindOf: PasteUpMorph) ifFalse: [
		^ self inform: 'This is not a PasteUpMorph or exported Project.'].
	(window _ self newMorphicProjectOn: morphOrList) openInWorld.
	window model enter