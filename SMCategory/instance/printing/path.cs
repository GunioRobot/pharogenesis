path
	"Return my name with a full path of my
	parent names separated with slashes like:
		'Squeak versions/Squeak3.5' "

	^String streamContents: [:s |
		self parentsDo: [:cat |
			s nextPutAll: cat name; nextPutAll: '/'].
		s nextPutAll: self name]