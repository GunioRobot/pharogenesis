diagnostics
	"This prints a status report on transcript about the package
	releases intended for the Full image."
	
	"ImageBuilder new diagnostics"
	
	"First find unpublished releases, or those not marked for the current version"
	| problematic candidates candidate maybes |
	
	Transcript cr; cr; show: 'Checking for problematic releases...';cr.
	problematic _ self releases select: [:rel |
					(rel isPublished not
						or: [rel isCompatibleWithCurrentSystemVersion not])
							or: [ self releaseNotInFull: rel]].
	problematic do: [:rel |
		Transcript show: rel printString, ':'.
		rel isPublished ifFalse: [Transcript show: 'NOT PUBLISHED, '].
		rel isCompatibleWithCurrentSystemVersion ifFalse: [Transcript show: 'NOT MARKED FOR CURRENT VERSION, '].
		(self releaseNotInFull: rel) ifTrue: [Transcript show: 'NOT MARKED FOR OFFICAL FULL IMAGE'].
		Transcript cr].
	Transcript show: (self printEmailsFor: problematic).

	"Next find packages which have newer releases that are published and for current system version, these should simply be added."
	Transcript cr;cr ; show: 'Checking for new candidate releases...';cr.
	candidates _ self releases select: [:rel |
		candidate _ rel package lastPublishedReleaseForCurrentSystemVersion.
		candidate ifNil: [false] ifNotNil: [candidate newerThan: rel]].
	candidates do: [:rel |	Transcript show: rel printString, ': NEWER PUBLISHED AND FOR CURRENT VERSION AVAILABLE';cr].
	Transcript show: (self printEmailsFor: candidates).

	"Next find packages which have newer releases that are not published and for current system version, might be added."
	Transcript cr;cr; show: 'Checking for possible new releases...';cr.
	maybes _ self releases select: [:rel | rel package releases anySatisfy: [:r | r newerThan: rel]].
	maybes do: [:rel |	Transcript show: rel printString, ': NEWER RELEASE AVAILABLE';cr].
	Transcript show: (self printEmailsFor: maybes).
	
	"Finally print an email list for all involved package maintainers"
	Transcript cr;cr; show: 'All maintainers and co-maintainers of all releases:';cr.
	Transcript show: (self printEmailsFor: self releases)