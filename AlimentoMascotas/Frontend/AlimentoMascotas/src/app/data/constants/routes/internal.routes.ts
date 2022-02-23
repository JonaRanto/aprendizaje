export const ROUTES_PATHS = {
    PUBLIC: {
        DEFAULT: '',
    },
    AUTH: {
        DEFAULT: 'login',
    },
    PRIVATE: {
        DEFAULT: 'private',
    }
}

export const INTERNAL_PATHS = {
    PUBLIC_DEFAULT: `${ROUTES_PATHS.PUBLIC.DEFAULT}`,
    AUTH_DEFAULT: `${ROUTES_PATHS.AUTH.DEFAULT}`,
    PRIVATE_DEFAULT: `${ROUTES_PATHS.PRIVATE.DEFAULT}`,
}

export const INTERNAL_ROUTES = {
    PUBLIC_MAIN: `${INTERNAL_PATHS.PUBLIC_DEFAULT}`,
}
