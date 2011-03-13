installingRBEngine

	"| `@temps |
``@.BeforeStatements.
`f := ImporterFacade forVisualWorks.
`f inModel: `@m.
`f importingContext importMaximum.
`f importNameSpaceFromBinding: `@n.
``@.AfterStatements

->

| `@temps |
``@.BeforeStatements.
ImporterFacade importNameSpaceFromVWBinding: `@n inModel: `@m.
``@.AfterStatements"

	(self universalInstaller) universe install: 'Refactoring Core'