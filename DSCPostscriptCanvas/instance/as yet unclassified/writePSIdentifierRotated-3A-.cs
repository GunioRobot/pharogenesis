writePSIdentifierRotated: rotateFlag
	"NB: rotation not yet supported"

	^target print:'%!'; cr.	" cannot use the DSC-compliance header yet! "
	" target	print:'%!PS-Adobe-2.0'; cr; 
			print:'%%Pages: (atend)'; cr;
			print:'%%BoundingBox: '; write:self pageBBox rounded; cr;
			print:'%%EndComments'; cr. "

