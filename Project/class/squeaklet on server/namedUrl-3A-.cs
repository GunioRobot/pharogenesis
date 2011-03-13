namedUrl: urlString
	| projName |
	"Return project if in, else nil"

	"Ted's fix for unreachable projects"

	projName _ (urlString findTokens: '/') last.
	projName _ (Project parseProjectFileName: projName unescapePercents) first.
	^ Project named: projName
