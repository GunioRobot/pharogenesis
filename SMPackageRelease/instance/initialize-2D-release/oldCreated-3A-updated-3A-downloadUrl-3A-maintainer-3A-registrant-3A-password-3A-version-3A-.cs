oldCreated: c updated: u downloadUrl: du maintainer: m registrant: r password: p version: v
	"Deprecated. Only kept for migration from SM 1.0x.
	Method used when recreating from storeOn: format."

	created _ c.
	updated _ u.
	downloadUrl _ du.
	map findOrCreatePublisher: m password: p package: package.
	version _ v