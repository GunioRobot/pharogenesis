partitionReleases
	"Move releases from wantedReleases to suitable other collections
	if they are either installed, trivial to install, or installable as is."
	
	trickyReleases := wantedReleases copy.
	alreadyInstalled := wantedReleases select: [:r | r isInstalled ].
	trickyReleases removeAll: alreadyInstalled. 
	trivialToInstall := trickyReleases select: [:r | r hasNoConfigurations ].
	trickyReleases removeAll: trivialToInstall.		
	alreadyInstallable := trickyReleases select: [:r | r hasFulfilledConfiguration ].
	trickyReleases removeAll: alreadyInstallable