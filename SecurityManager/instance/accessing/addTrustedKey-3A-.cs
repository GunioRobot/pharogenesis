addTrustedKey: aPublicKey
	"Add a public key to the list of trusted keys"
	trustedKeys _ (trustedKeys copyWithout: aPublicKey) copyWith: aPublicKey.