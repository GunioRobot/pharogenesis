printOn: aStream
	| aSelector className aClass |
	aSelector _ class selectorAtMethod: method setClass: [:c | aClass _ c].
	className _ aClass name contractTo: 30.
	aStream nextPutAll: className; nextPutAll: ' >> ';
			nextPutAll: (aSelector contractTo: 60-className size)