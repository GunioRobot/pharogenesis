initializeForWorld: aWorld

	world _ aWorld.
	clients _ IdentitySet new.
	self extent: world extent depth: Display depth.
	aWorld remoteServer: self.