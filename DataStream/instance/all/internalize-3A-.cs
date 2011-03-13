internalize: externalObject
    "PRIVATE -- We just read externalObject. Give it a chance to
        internalize. Return the internalized object."

    ^ externalObject comeFullyUpOnReload