optimalExtent
	"Create a new paragraph and answer its extent."
	
	^(self paragraphClass new
		compose: text
		style: textStyle copy
		from: 1
		in: (0@0 extent: 9999999@9999999);
		adjustRightX;
		extent) + (self borderWidth * 2) + (2@0) "FreeType kerning allowance"