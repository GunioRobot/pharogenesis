calculateDeviations
	"Calculate deviations. Currently we just pick the newest release."

	| conflicts newest |
	deviations := OrderedCollection new.
	conflicts := self collectConflictsIn: installList.
	conflicts keysAndValuesDo: [:package :releases |
		newest := releases first.
		releases do: [:r | (r newerThan: newest) ifTrue: [newest := r]].
		deviations add: (SMInstallationDeviation selectedRelease: newest releases: installList)]