testcheckForCoverage

self should: ['.' asNumber = nil] raise: Error.
self should: ['1.' asNumber = 1].
self should: ['.1' asNumber = nil] raise: Error.