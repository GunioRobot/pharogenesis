printOn: aStream level: level

	variable printOn: aStream level: level.
	aStream nextPutAll: ' _ '.
	expression printOn: aStream level: level + 2.