rename: oldFileName toBe: newFileName 
	^ self primitiveRename: (self fullNameFor: oldFileName)
						toBe: (self fullNameFor: newFileName) 
