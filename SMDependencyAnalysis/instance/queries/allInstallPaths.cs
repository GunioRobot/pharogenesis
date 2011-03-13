allInstallPaths
	"For all paths, collect in reverse all releases to install.
	At each level, first we add trivially installable releases
	(those that have no dependencies), then installable releases
	(those that have one configuration fulfilled) and finally
	the tricky releases (those left).
	Note that we also return paths with conflicting releases
	of the same package and paths with releases that conflict with
	already installed releases - those paths can be tweaked - and
	paths that are supersets of other paths."

	| installPaths releases |
	installPaths := OrderedCollection new.
	self allPathsDo: [:path |
		releases := OrderedCollection new.
		path reverseDo: [:ana |
			releases addAll: (ana trivialToInstall difference: releases).
			releases addAll: (ana alreadyInstallable difference: releases).
			releases addAll: (ana trickyReleases difference: releases)
			"Below for debugging
			r := OrderedCollection new.
			r add: ana trivialToInstall; add: ana alreadyInstallable; add: ana trickyReleases.
			releases add: r"].
		installPaths add: releases].
	^ installPaths