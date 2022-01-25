import { FormControl, FormGroup, Validators } from "@angular/forms";

export const CONST_LOGIN_PAGE: {
    LOGIN_FORM: FormGroup;
} = {
    LOGIN_FORM: new FormGroup({
        email: new FormControl('', [Validators.required, Validators.email]),
        pass: new FormControl('', [Validators.required, Validators.pattern(/^(?=(?:.*\d))(?=.*[A-Z])(?=.*[a-z])(?=.*[.,*!?¿¡/#$%&])\S{8,64}$/)])
    })
}
