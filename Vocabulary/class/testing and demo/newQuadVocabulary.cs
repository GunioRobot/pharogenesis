newQuadVocabulary
	"Answer a Quad vocabulary -- something to mess with, to illustrate and explore ideas.  Applies to Quadrangles only."

	| aVocabulary  |
	aVocabulary _ Vocabulary new vocabularyName: #Quad.
	aVocabulary documentation: 'A highly restricted test vocabulary that can be used with Quadrangle objects'.
	aVocabulary initializeFromTable:  #(
(borderColor borderColor: () Color (basic color) 'The color of the border' unused updating)
(borderWidth borderWidth: () Number (basic geometry) 'The width of the border' unused updating)
(insideColor insideColor: () Color (basic color) 'The color of the quadrangle' unused updating)
(display none () none (basic display) 'Display the quadrangle directly on the screen')
(width none () Number (geometry) 'The width of the object' unused updating)
(left setLeft: () Number (geometry) 'The left edge' unused updating)
(right setRight: () Number (geometry) 'The right edge' unused updating)
(width setWidth: () Number (geometry) 'The width of the object' unused updating)
(height setHeight: () Number (geometry) 'The height of the object' unused updating)
(hasPositiveExtent none () Boolean (tests) 'Whether the corner is to the lower-right of the origin' unused updating)
(isTall none () Boolean (tests) 'Whether the height is greater than the width' unused updating)).

	^ aVocabulary

"Vocabulary initialize"
"Quadrangle exampleInViewer"