proposals
	"Return all different possible proposals to install
	sorted with the best proposal first."

	^analysis allNormalizedInstallPaths collect: [:path | SMInstallationProposal installList: path]