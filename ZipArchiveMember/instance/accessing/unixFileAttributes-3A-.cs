unixFileAttributes: perms
	| oldPerms newPerms |
	oldPerms _ self mapPermissionsToUnix: externalFileAttributes.
	newPerms _  self isDirectory
			ifTrue: [ (perms bitAnd: FileAttrib bitInvert) bitOr: DirectoryAttrib ]
			ifFalse: [ (perms bitAnd: DirectoryAttrib bitInvert) bitOr: FileAttrib ].
	externalFileAttributes _ self mapPermissionsFromUnix: newPerms.
	^oldPerms.