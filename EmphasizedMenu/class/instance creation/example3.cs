example3
	"An example of how to get an EmphasizedMenu to work for you.  "

	^ (self selectionAndEmphasisPairs: 
		#('how' bold   'well'	0  'does'  italic   'this'  struckOut  'work' plain))
		startUpWithCaption: 'A Menu with Emphases'

"EmphasizedMenu example3"