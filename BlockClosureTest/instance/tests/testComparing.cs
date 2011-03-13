testComparing
	"self debug: #testComparing"
	
	self shouldnt: [(BlockClosureTest>>#exempleBlock) = (BlockClosureTest>>#exempleBlock)] raise: Error.
	self assert: (BlockClosureTest>>#exempleBlock) = (BlockClosureTest>>#exempleBlock).
	self assert: ((BlockClosureTest>>#exempleBlock) valueWithReceiver: self arguments: #()) = 20