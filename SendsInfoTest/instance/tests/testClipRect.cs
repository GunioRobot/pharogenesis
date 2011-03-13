testClipRect
	self assert: #clipRect:  sends: #(bitBlt)  supersends: #(clipRect:)  classSends: #() 
