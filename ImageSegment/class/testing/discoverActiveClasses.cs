discoverActiveClasses   "ImageSegment discoverActiveClasses" 
	"Run this method, do a few things, save and resume the image.
	This will leave unused classes with MDFaults.
	You MUST follow this soon by activeClasses, or by swapOutInactiveClasses."

	| ok |
	Smalltalk allClasses do:
		[:c | ok _ true.
		#(Array Object Class Message MethodDictionary) do:
			[:n | ((Smalltalk at: n) == c or:
				[(Smalltalk at: n) inheritsFrom: c]) ifTrue: [ok _ false]].
		ok ifTrue: [c induceMDFault]].
"
	ImageSegment discoverActiveClasses.
		-- do something typical --
	PopUpMenu notify: ImageSegment activeClasses size printString , ' classes were active out of ' ,
			Smalltalk allClasses size printString.
"