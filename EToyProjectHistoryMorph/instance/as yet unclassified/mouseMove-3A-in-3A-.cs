mouseMove: evt in: aMorph

	| start tuple project url pvm |
	start _ aMorph valueOfProperty: #mouseDownPoint ifAbsent: [^self].
	(start dist: evt cursorPoint) abs < 5 ifTrue: [^self].
	aMorph removeProperty: #mouseDownPoint.
	evt hand hasSubmorphs ifTrue: [^self].
	tuple _ aMorph valueOfProperty: #projectParametersTuple ifAbsent: [^self].
	project _ tuple fourth first.
	(project notNil and: [project world notNil]) ifTrue: [
		^evt hand attachMorph: (ProjectViewMorph on: project).
	].
	url _ tuple third.
	url isEmptyOrNil ifTrue: [^self].
	pvm _ ProjectViewMorph new.
	pvm
		project: (DiskProxy global: #Project selector: #namedUrl: args: {url});
		lastProjectThumbnail: tuple second.
	evt hand attachMorph: pvm.
