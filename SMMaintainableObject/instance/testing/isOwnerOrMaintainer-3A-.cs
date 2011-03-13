isOwnerOrMaintainer: anAccount
	^ owner = anAccount or: [self maintainers includes: anAccount]