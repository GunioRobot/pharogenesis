analyze: aString with: nonMethod
	"Initalize this attribute holder with a piece text the user typed into a paragraph.  Returns the text to emphesize (may be different from selection)  Does not return self!.  nonMethod is what to show when clicked, i.e. the last part of specifier (Comment, Definition, or Hierarchy).  May be of the form:
Point
<Point>
Click Here<Point>
<Point>Click Here
"
	"Obtain the showing text and the instructions"
	| b1 b2 trim |
	b1 _ aString indexOf: $<.
	b2 _ aString indexOf: $>.
	(b1 < b2) & (b1 > 0) ifFalse: ["only one part"
		classAndMethod _ self validate: aString, ' ', nonMethod.
		^ classAndMethod ifNotNil: [aString]].
	"Two parts"
	trim _ aString withBlanksTrimmed.
	(trim at: 1) == $< 
		ifTrue: [(trim last) == $>
			ifTrue: ["only instructions" 
				classAndMethod _ self validate: (aString copyFrom: b1+1 to: b2-1), ' ', nonMethod.
				^ classAndMethod ifNotNil: [classAndMethod]]
			ifFalse: ["at the front"
				classAndMethod _ self validate: (aString copyFrom: b1+1 to: b2-1), ' ', nonMethod.
				^ classAndMethod ifNotNil: [aString copyFrom: b2+1 to: aString size]]]
		ifFalse: [(trim last) == $>
			ifTrue: ["at the end"
				classAndMethod _ self validate: (aString copyFrom: b1+1 to: b2-1), ' ', nonMethod.
				^ classAndMethod ifNotNil: [aString copyFrom: 1 to: b1-1]]
			ifFalse: ["Illegal -- <> has text on both sides"
				^ nil]]
