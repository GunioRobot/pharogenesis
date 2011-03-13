printOn: aStream
	| aSelector className |
	aSelector _ class selectorAtMethod: method setClass: [:aClass].
	className _ aClass name contractTo: 30.
	aStream nextPutAll: className; nextPutAll: ' >> ';
			nextPutAll: (aSelector contractTo: 60-className size)