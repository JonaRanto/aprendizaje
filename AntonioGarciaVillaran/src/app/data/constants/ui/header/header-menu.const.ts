import { IHeaderMenu } from "@data/interfaces";

export const HEADER_MENUS: IHeaderMenu[] = [
    {
        name: 'Libros',
        link: 'https://www.amazon.es/tener-talento-Revoluci%C3%B3n-Hamparte-4You2/dp/8427045603/?tag=latte0a-21',
        target: '_blank'
    },
    {
        name: 'Cursos',
        link: 'https://www.udemy.com/user/antoniogv/',
        target: '',
        subMenus: [
            {
                name: 'Pintura al óleo',
                link: 'https://www.udemy.com/course/pintar-un-cuadro-al-oleo-mi-proceso-tecnica-y-secretos/?couponCode=A92B5092CF4204BD2CDF',
                target: '_blank'
            },
            {
                name: 'Pinta 5 cuadros en 5 días con pintura acrílica',
                link: 'https://www.udemy.com/course/pinta-5-cuadros-en-5-dias-con-pintura-acrilica/?couponCode=1C5DD9DD015336E6A76D',
                target: '_blank'
            },
            {
                name: 'Dibujo',
                link: 'https://www.udemy.com/course/dibujo-artistico-curso-basico-aprende-a-dibujar-facilmente/?couponCode=8381436CD6016368FD93',
                target: '_blank'
            },
            {
                name: 'Técnicas de Arte y Creatividad',
                link: 'https://www.udemy.com/course/mas-de-40-tecnicas-de-arte-y-creatividad-dibujo-y-pintura/?couponCode=E8B83EB0A2D6DDD0FB36',
                target: '_blank'
            },
            {
                name: 'Dibujo 2° nivel',
                link: 'https://www.udemy.com/course/2o-nivel-aprende-dibujo-artistico-facilmente-figura-humana/?couponCode=AE19F217D933A8BD9FC9',
                target: '_blank'
            },
            {
                name: 'Retrato',
                link: 'https://www.udemy.com/course/el-arte-del-retrato-dibuja-y-pinta-el-rostro-humano/?couponCode=E878AB97E8ECF6765544',
                target: '_blank'
            },
            {
                name: 'Libros de Artista',
                link: 'https://www.udemy.com/course/el-libro-de-artista-concepto-fabricacion-y-venta/?couponCode=9282ECB38EA55E668E3A',
                target: '_blank'
            },
            {
                name: 'Tinta China',
                link: 'https://www.udemy.com/course/dibuja-con-tinta-china-concepto-fabricacion-y-ejercicios/?couponCode=B407BD06A83279240E63',
                target: '_blank'
            }
        ]
    },
    {
        name: 'Obra',
        link: 'https://tienda.antoniogarciavillaran.es/',
        target: '_blank'
    },
    {
        name: 'Libros y Materiales Preferidos',
        link: '/',
        target: '',
        subMenus: [
            {
                name: 'Teoría del Arte',
                link: '/',
                target: ''
            },
            {
                name: 'Arte Oriental',
                link: '/',
                target: ''
            },
            {
                name: 'Dibujar y Pintar',
                link: '/',
                target: ''
            },
            {
                name: 'Libros Oscuros',
                link: '/',
                target: ''
            },
            {
                name: 'Esqueletos y Modelos',
                link: '/',
                target: ''
            },
            {
                name: 'Cámaras y Equipamiento',
                link: '/',
                target: ''
            },
            {
                name: 'Materiales de Dibujos y Piuntura',
                link: '/',
                target: ''
            }
        ]
    },
    {
        name: 'Contacto',
        link: '',
        target: ''
    }
]
