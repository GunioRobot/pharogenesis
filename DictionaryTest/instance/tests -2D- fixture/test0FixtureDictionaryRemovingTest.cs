test0FixtureDictionaryRemovingTest

self shouldnt: [self nonEmptyDict ] raise: Error.
self deny: self nonEmptyDict  isEmpty.

self shouldnt: [self keyNotInNonEmptyDict ] raise: Error.
self deny: (self nonEmptyDict keys includes: self keyNotInNonEmptyDict ).