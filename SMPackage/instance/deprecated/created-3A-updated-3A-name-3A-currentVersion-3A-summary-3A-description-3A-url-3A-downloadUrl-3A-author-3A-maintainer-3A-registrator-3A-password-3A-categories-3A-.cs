created: c updated: u name: n currentVersion: v summary: s description: d url: ur downloadUrl: du author: a maintainer: m registrator: r password: p categories: cats 
	"Deprecated. Only kept for migration from SM 1.0x.
	Method used when recreating from storeOn: format.
	A few attributes are moved over from the card and the release
	is given the same categories as the card to begin with."

	self isReleased ifFalse:[self newRelease].
	self lastRelease
		oldCreated: c updated: u downloadUrl: du maintainer: m registrant: r password: p version: v;
		categories: cats.
	self categories: cats.
	created _ c.
	updated _ u.
	name _ n.
	summary _ s.
	description _ d.
	url _ ur.
	author _ a	