packageSpecificOptions
	| choices packageOrRelease |
	packageOrRelease := self selectedPackageOrRelease.
	choices := OrderedCollection new.
	packageOrRelease isInstallable ifTrue: [
		choices add: #('install' #installPackageRelease 'Install selected package or release, first downloading into the cache if needed.')].	
	(packageOrRelease isDownloadable and: [packageOrRelease isCached]) ifTrue: [
		choices add: #('browse cache' #browseCacheDirectory 'Browse cache directory of selected package or package release.')].

	(packageOrRelease isPackageRelease and: [packageOrRelease isDownloadable]) ifTrue: [
		choices add: #('copy from cache' #cachePackageReleaseAndOfferToCopy 'Download selected release into cache first if needed, and then offer to copy it somewhere else.' ).
		choices add: #('force download into cache' #downloadPackageRelease 'Force a download of the selected release into the cache.' )].
	choices add: #('email package maintainers' emailPackageMaintainers 'Open an editor to send an email to the owner and co-maintainers of this package.').
	^ choices