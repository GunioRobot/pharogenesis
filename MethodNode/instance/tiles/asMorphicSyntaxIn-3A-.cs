asMorphicSyntaxIn: morph
	| header tempMorph selNode |

	selNode _ selectorOrFalse class == SelectorNode 
		ifTrue: [selectorOrFalse] 
		ifFalse: [SelectorNode new key: selectorOrFalse code: nil].
	header _ morph addRow: Color white on: selNode.
	precedence = 1
		ifTrue: [header addToken: self selector type: #keyword1 on: selNode]
		ifFalse: [self selector keywords with: arguments do:
					[:kwd :arg | 
					header addToken: kwd type: #keyword2 on: selNode.
					(arg asMorphicSyntaxIn: header) color: #blockarg2]].
	self addCommentToMorph: morph.
	temporaries size > 0 ifTrue: [
		tempMorph _ morph addRow: #tempVariable on: (MethodTempsNode new).
		temporaries do: [:temp | temp asMorphicSyntaxIn: tempMorph ]
				separatedBy: [tempMorph addMorphBack: (tempMorph transparentSpacerOfSize: 4@4)]].
	(primitive > 0 and: [(primitive between: 255 and: 519) not]) ifTrue:
		["Dont decompile <prim> for, eg, ^ self "
		morph addTextRow: (String streamContents: [ :strm | self printPrimitiveOn: strm])].
	block asMorphicSyntaxIn: morph.
	^ morph
