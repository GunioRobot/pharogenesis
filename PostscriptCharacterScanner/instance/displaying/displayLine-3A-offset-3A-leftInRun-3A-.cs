displayLine: line offset: baseOffset leftInRun: leftInRun
   | drawFont offset |
   self setTextStylesForOffset:((line first) + 1).		" sets up various instance vars from text styles "
   drawFont _ self font.
   offset _ baseOffset.
   offset _ offset + (bounds origin x @ (line top + line baseline - drawFont ascent )). 
   offset _ offset + ((self textStyle alignment caseOf:{
	[2] -> [ line paddingWidth /2 ].
	[1] -> [ line paddingWidth ] } otherwise:[0]) @ 0).

   " missing: support for justified text "

   canvas text: ((paragraph string) copyFrom:line first to:line last)
            at:  offset 
            font:drawFont
            color:foregroundColor
		  justified:((paragraph textStyle alignment = 3) and:[ (paragraph text at:line last) ~= Character cr ]) 
		  parwidth:paragraph extent x.
