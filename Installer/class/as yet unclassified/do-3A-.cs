do: webPageName

self webSearchPath isEmpty ifTrue: [ ^self error: 'search path not set' ].

^(self new package: webPageName) install.
