testDirectoryExistsWhenLikeNamedFileExists

| testFileName |
[testFileName := self myAssuredDirectory fullNameFor: 'zDirExistsTest.testing'.
(FileStream newFileNamed: testFileName) close.

self should: [FileStream isAFileNamed: testFileName].
self shouldnt: [(FileDirectory on: testFileName) exists]]
ensure: [self myAssuredDirectory deleteFileNamed: 'zDirExistsTest.testing']

