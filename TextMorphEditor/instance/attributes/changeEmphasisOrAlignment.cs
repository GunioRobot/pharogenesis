changeEmphasisOrAlignment
	| aList reply  code align menuList |
	self flag: #arNote. "Move this up once we get rid of MVC"
	aList _ #(plain bold italic narrow underlined struckOut leftFlush centered rightFlush justified).	
	align _ paragraph textStyle alignmentSymbol.
	code _ paragraph text emphasisAt: startBlock stringIndex.
	menuList _ WriteStream on: Array new.
	menuList nextPut: (code = 0 ifTrue:['<on>plain'] ifFalse:['<off>plain']).
	menuList nextPutAll: (#(bold italic underlined struckOut) collect:[:emph|
		(code anyMask: (TextEmphasis perform: emph) emphasisCode)
			ifTrue:['<on>', emph]
			ifFalse:['<off>',emph]]).
	((paragraph text attributesAt: startBlock stringIndex forStyle: paragraph textStyle)
		anySatisfy:[:attr| attr isKern and:[attr kern < 0]]) 
			ifTrue:[menuList nextPut:'<on>narrow']
			ifFalse:[menuList nextPut:'<off>narrow'].
	menuList nextPutAll: (#(leftFlush centered rightFlush justified) collect:[:type|
		align == type
			ifTrue:['<on>',type]
			ifFalse:['<off>',type]]).
	aList _ #(plain bold italic underlined struckOut narrow leftFlush centered rightFlush justified).
	reply _ (SelectionMenu labelList: menuList contents lines: #(1 6) selections: aList) startUp.
	reply ~~ nil ifTrue:
		[(#(leftFlush centered rightFlush justified) includes: reply)
			ifTrue:
				[paragraph perform: reply.
				self recomputeInterval]
			ifFalse:
				[self setEmphasis: reply.
				paragraph composeAll.
				self recomputeSelection.
				self mvcRedisplay]].
	^ true