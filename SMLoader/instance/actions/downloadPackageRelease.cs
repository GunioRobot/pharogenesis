downloadPackageRelease
	"Force a download of the selected package release into the cache."

	| release |
	release := self selectedPackageOrRelease.
	release isPackageRelease ifFalse: [ self error: 'Should be a package release!'].
	[Cursor wait showWhile: [
		(SMInstaller forPackageRelease: release) download]
	] on: Error do: [:ex |
		| msg | 
		msg := ex messageText ifNil: [ex asString].
		self informException: ex msg: ('Error occurred during download:\', msg, '\') withCRs]